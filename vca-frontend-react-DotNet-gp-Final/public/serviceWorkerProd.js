console.warn('service worker prod registered')
// Service worker for Production
// to store following react bundles into browser cache storage
let cacheData = 'appV1';
this.addEventListener('install', (event) => {
    event.waitUntil(
        caches.open(cacheData).then((cache) => {
            cache.add([  
                "/favicon.ico",
                "logo192.png",
                "logo512.png",
                "/manifest.json",
                "/index.html",
                "/"])
            cache.addAll([...array])
        })
    );
});

// to fetch data from browser cache storage incase of offline
this.addEventListener('fetch', (event) => {
    if (!navigator.onLine) {
        event.respondWith(
            caches.match(event.request).then((resp) => {
                if (resp) {
                    return resp;
                }
                // let requestUrl = event.request.clone();
                // fetch(requestUrl);
            })
        );
    }
});
