
import { app, router, store } from './app';

export default context => {
  return new Promise((resolve, reject) => {
    router.push(context.url);

    router.onReady(() => {
      const matchedComponents = router.getMatchedComponents()
      if (!matchedComponents.length) {
        return reject({ code: 404 });
      }
      console.log('matchedComponents', matchedComponents);
      Promise.all(matchedComponents.map(Component => {
        if (Component.asyncData) {
          return Component.asyncData({
            store
          });
        }
      })).then(() => {
        // store.replaceState(context);
        context.state = store.state;
        resolve(app);
      }).catch(reject)
    }, reject)
  })
};