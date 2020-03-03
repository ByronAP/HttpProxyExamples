// `reqwest = { version = "0.10.3" }`
// `tokio = { version = "0.2", features = ["macros"] }`

extern crate reqwest;
extern crate tokio;

const PROXY_ADDRESS: &str = "rotate.proxy.services";
const PROXY_PORT: i32 = 8989;
const PROXY_USERNAME: &str = "Username";
const PROXY_PASSWORD: &str = "Password";
const URL_ADDRESS: &str = "https://echo.proxy.services";

#[tokio::main]
async fn main() -> Result<(), reqwest::Error> {
    let proxy_url = format!("http://{}:{}@{}:{}",
        PROXY_USERNAME,
        PROXY_PASSWORD,
        PROXY_ADDRESS,
        PROXY_PORT);
    let proxy = reqwest::Proxy::all(&proxy_url).expect("proxy should be there");
    let client = reqwest::Client::builder()
        .proxy(proxy)
        .build()
        .expect("should be able to build reqwest client");

    let res = client.get(URL_ADDRESS).send().await?;

    println!("Status: {}", res.status());

    let text = res.text().await?;

    println!("{}", text);

    Ok(())
}