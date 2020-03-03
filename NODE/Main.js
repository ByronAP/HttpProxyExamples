const request = require('request');
const proxyAddress = 'rotate.proxy.services';
const proxyPort = 8989;
const proxyUsername = 'Username';
const proxyPassword = 'Password';
const url = 'https://echo.proxy.services';

request({
    'url': `${url}`,
    'method': "GET",
    'proxy':`http://${proxyUsername}:${proxyPassword}@${proxyAddress}:${proxyPort}`
},function (error, response, body) {
    if (!error && response.statusCode === 200) {
        console.log(body);
    }else{
        console.log(error);
    }
})