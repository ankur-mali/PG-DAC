console.warn('service worker dev registered')
// Service worker for Development
// to store following react bundles into browser cache storage
let cacheData = 'appV1';
this.addEventListener('install', (event) => {
    event.waitUntil(
        caches.open(cacheData).then((cache) => {
            cache.addAll([  
                "/favicon.ico",
                "logo192.png",
                "logo512.png",
                "/manifest.json",
                "static/js/bundle.js",
                "http://localhost:3000/static/media/carsearch.3bf4a2dd37d3d488a73e.webp",
                "http://localhost:3000/static/media/carplus.42195b808d36491b9bd5.webp",
                "https://fonts.googleapis.com/css2?family=Nunito&display=swap",
                "http://localhost:3000/static/media/gstore.50cb38176a0bde6e48ac.webp",
                "http://localhost:3000/static/media/appstore.41445d9bd413fd71be57.webp",
                "http://localhost:3000/static/media/fleet-banner.c5d4f898f4cb8c8b1dc5.jpg",
                "/index.html",
                "/",
                "/login",
                "/register",
                "/car-details",
                "/car-configure"
                ])
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


 