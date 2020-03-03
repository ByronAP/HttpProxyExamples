// be sure to enable tunneling and proxying schemas in your java config
// SEE: http://www.oracle.com/technetwork/java/javase/8u111-relnotes-3124969.html
package services.proxy;

import java.io.BufferedReader;
import java.io.Console;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.*;

public class Main {

    public static void main(String[] args) throws IOException, InterruptedException {
        String proxyAddress = "rotate.proxy.services";
        Integer proxyPort = 8989;
        String proxyUsername = "Username";
        String proxyPassword = "Password";
        URL url = new URL("https://echo.proxy.services");

        Proxy webProxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress(proxyAddress, proxyPort));

        Authenticator auth = new Authenticator() {
            public PasswordAuthentication getPasswordAuthentication() {
                return (new PasswordAuthentication(proxyUsername, proxyPassword.toCharArray()));
            }
        };
        Authenticator.setDefault(auth);

        HttpURLConnection webProxyConnection = (HttpURLConnection) url.openConnection(webProxy);

        BufferedReader reader = new BufferedReader(new InputStreamReader(webProxyConnection.getInputStream()));

        String line;
        while ((line = reader.readLine()) != null)
        {
            System.out.println(line);
        }

        reader.close();
    }
}