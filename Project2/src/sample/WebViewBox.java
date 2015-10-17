package sample;

import javafx.scene.control.ProgressIndicator;
import javafx.scene.layout.StackPane;
import javafx.scene.layout.VBox;
import javafx.scene.web.WebEngine;
import javafx.scene.web.WebView;

/**
 * Created by alexknipfer on 10/16/15.
 */
public class WebViewBox extends VBox {

    private WebView browser;
    private WebEngine engine;
    private ProgressIndicator indicator;
    private StackPane holder;

    public WebViewBox(String url){
        buildVBox(url, 150);
    }

    private void buildVBox(String loadURL, int webWidth){

        browser = new WebView();
        engine = browser.getEngine();

        browser.setMaxWidth(webWidth);
        browser.setMaxHeight(200);

        holder = new StackPane();
        holder.getChildren().add(browser);

        this.getChildren().addAll(holder);
        engine.load(loadURL);
    }

}
