<?php
use Symfony\Component\HttpClient\CurlHttpClient;
$url = 'https://echo.proxy.services';
$proxyAuth = 'user:pass';
$proxyAddress = 'rotate.proxy.services';
$proxyPort = '8989';

$httpClient = new CurlHttpClient([
    'http_version' => '2.0',
    'proxy' => 'http://$proxyAuth@$proxyAddress:$proxyPort',
]);

$output = $httpClient->request('GET', $url)->getContent();

echo $output;