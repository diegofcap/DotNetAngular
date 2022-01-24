const PROXY_CONFIG = [{
    context: [
        "/vehicles",
        "/vehicletypes",
    ],
    target: "http://localhost:8080",
    secure: false
}]

module.exports = PROXY_CONFIG;