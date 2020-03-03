package main

import (
	"encoding/base64"
	"io/ioutil"
	"log"
	"net/http"
	"net/url"
	"strconv"
)

func main() {
	proxyAddress := "http://rotate.proxy.services"
	proxyPort := 8989
	proxyAuth := "Username:Password"
	urlStr := "https://echo.proxy.services"
	proxyURL, err := url.Parse(proxyAddress + ":" + strconv.Itoa(proxyPort))
	if err != nil {
		log.Println(err)
	}

	url, err := url.Parse(urlStr)
	if err != nil {
		log.Println(err)
	}

	basicAuth := "Basic " + base64.StdEncoding.EncodeToString([]byte(proxyAuth))
	headers := http.Header{}
	headers.Add("Proxy-Authorization", basicAuth)

	transport := &http.Transport{
		Proxy: http.ProxyURL(proxyURL),
		ProxyConnectHeader: headers,
	}

	client := &http.Client{
		Transport: transport,
	}

	request, err := http.NewRequest("GET", url.String(), nil)
	if err != nil {
		log.Println(err)
	}

	response, err := client.Do(request)
	if err != nil {
		log.Println(err)
	}

	data, err := ioutil.ReadAll(response.Body)
	if err != nil {
		log.Println(err)
	}

	log.Println(string(data))
}