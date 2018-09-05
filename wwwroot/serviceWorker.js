var AppShellCacheName = 'AppShell-v4';
var AppDataCacheName = 'AppData-v5';

var filesToCache = [
  '/favicon.ico',
  '/images/logo.png',
  '/images/loader.gif',
  '/images/dressPlaceholder.gif',
  '/images/imageNotAvailable.png',

];

self.addEventListener('install', function(e) {
  console.log('[ServiceWorker] Install');
  // integrate workbox for offline
  importScripts('https://storage.googleapis.com/workbox-cdn/releases/3.4.1/workbox-sw.js');

  if (workbox) {
    console.log(`Yay! Workbox is loaded 🎉`);
    // workbox.routing.registerRoute(
    //   new RegExp('.*\.js'),
    //   workbox.strategies.networkFirst()
    // );
    // workbox.routing.registerRoute(
    //   // Cache CSS files
    //   /.*\.css/,
    //   // Use cache but update in the background ASAP
    //   workbox.strategies.staleWhileRevalidate({
    //     // Use a custom cache name
    //     cacheName: 'css-cache',
    //   })
    // );

    // workbox.routing.registerRoute(
    //   // Cache image files
    //   /.*\.(?:png|jpg|jpeg|svg|gif)/,
    //   // Use the cache if it's available
    //   workbox.strategies.cacheFirst({
    //     // Use a custom cache name
    //     cacheName: 'image-cache',
    //     plugins: [
    //       new workbox.expiration.Plugin({
    //         // Cache only 20 images
    //         maxEntries: 20,
    //         // Cache for a maximum of a week
    //         maxAgeSeconds: 7 * 24 * 60 * 60,
    //       })
    //     ],
    //   })
    // );
  } else {
    console.log(`Boo! Workbox didn't load 😬`);
  }

  e.waitUntil(
    caches.open(AppShellCacheName).then(function(cache) {
      console.log('[ServiceWorker] Caching app shell');
      return cache.addAll(filesToCache);
    })
  );
});

self.addEventListener('activate', function(e) {
  console.log('[ServiceWorker] Activate');
  e.waitUntil(
    caches.keys().then(function(keyList) {
      return Promise.all(keyList.map(function(key) {
        // we want to delete cache data that are not store in our cache
        if (key !== AppShellCacheName && key !== AppDataCacheName) {
          console.log('[ServiceWorker] Removing old cache', key);
          return caches.delete(key);
        }
      }));
    })
  );
  // self.clients.claim() essentially lets us activate the service worker faster.
  return self.clients.claim();
});

self.addEventListener('fetch', function(e) {
  console.log('[ServiceWorker] Fetch', e.request.url);
  var requestUrl = e.request.url;
  var apiUrl = '/api';
  if (requestUrl.indexOf(apiUrl) > -1) {
    /*
     * when the request URL contains apiUrl, we want to fetch data 
     * and then update the cache (network-then-cache)
     */
    e.respondWith(
      caches.open(AppDataCacheName).then(function(cache) {
        return fetch(e.request).then(function(response){
          cache.put(requestUrl, response.clone());
          return response;
        });
      })
    );
  } else {
    /*
     * Here, the request is not for the api but for the app shell, 
     * so we serve from the cache first then go to the network, when the network 
     * is successfully we update the cache
     */
    e.respondWith(
      caches.match(e.request).then(function(response) {
        return response || fetch(e.request);
      })
    );
  }
});


