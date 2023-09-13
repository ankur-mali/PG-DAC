// Service worker registration file
// Import in index.js and call

// checking whether you are in development or production mode
const isLocalhost = Boolean(
  window.location.hostname === 'localhost' ||
    // [::1] is the IPv6 localhost address.
    window.location.hostname === '[::1]' ||
    // 127.0.0.0/8 are considered localhost for IPv4.
    window.location.hostname.match(
      /^127(?:\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}$/
    )
)


export default function swRegister() {
  console.log(isLocalhost)
  let swUrl
  if(isLocalhost){
    swUrl = `${process.env.PUBLIC_URL}/serviceWorkerDev.js`
  } else swUrl = `${process.env.PUBLIC_URL}/serviceWorkerProd.js`

  navigator.serviceWorker.register(swUrl).then((response) => {
    // console.warn('response', response)
  })
}
