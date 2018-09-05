// Write your JavaScript code.
window.addEventListener('load', () => {
  if ('serviceWorker' in navigator) {
    console.log('came here');
    navigator.serviceWorker
             .register('../serviceWorker.js')
             .then(function() { console.log('Service Worker Registered'); });
  }
});

