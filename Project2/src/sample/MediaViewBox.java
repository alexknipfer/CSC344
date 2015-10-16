package sample;

import javafx.beans.InvalidationListener;
import javafx.beans.Observable;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.scene.control.Button;
import javafx.scene.control.ProgressBar;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.scene.media.Media;
import javafx.scene.media.MediaPlayer;
import javafx.scene.media.MediaView;
import javafx.util.Duration;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by alexknipfer on 10/15/15.
 */
public class MediaViewBox extends VBox {

    private Media media;
    private MediaPlayer player;
    private MediaView myView;

    private Button play;
    private Button pause;
    private ProgressBar progress;

    public static List<MediaView> myVideos = new ArrayList<MediaView>();

    public MediaViewBox(String fileName) {
        buildBox(fileName, 150);

    }

    private void buildBox(String url, double width) {

        media = new Media("file:" + url);

        player = new MediaPlayer(media);

        player.setAutoPlay(false);
        player.setCycleCount(1);

        myView = new MediaView();
        myView.setMediaPlayer(player);

        myVideos.add(myView);

        myView.addEventHandler(MouseEvent.MOUSE_ENTERED_TARGET, new EventHandler<MouseEvent>() {

            @Override
            public void handle(MouseEvent event) {
                myView.setFitWidth(myView.getFitWidth() * 2);

            }
        });

        myView.addEventHandler(MouseEvent.MOUSE_EXITED_TARGET, new EventHandler<MouseEvent>() {

            @Override
            public void handle(MouseEvent event) {
                myView.setFitWidth(myView.getFitWidth() / 2);

            }
        });

        progress = new ProgressBar(0);
        progress.setMinWidth(width);

        play = new Button(">");
        play.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                player.play();
            }
        });

        pause = new Button("||");
        pause.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                player.pause();
            }
        });

        player.currentTimeProperty().addListener(
                new InvalidationListener() {
                    @Override
                    public void invalidated(Observable observable) {
                        progress.setProgress(player.getCurrentTime().toSeconds() / player.getTotalDuration().toSeconds());
                    }
                }
        );


        HBox controls = new HBox();
        controls.getChildren().addAll(play, pause);

        this.getChildren().addAll(myView, progress, controls);

        myView.setFitWidth(width);
        myView.setPreserveRatio(true);


    }
}
