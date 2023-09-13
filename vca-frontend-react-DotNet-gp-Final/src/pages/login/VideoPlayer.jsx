import React from "react";
import "./Login"; // Import the CSS file

function VideoPlayer() {
  return (
    <div className="video-container">
      
      <video autoPlay loop muted>
        <source src="animation.mp4" type="video/mp4" />
        Your browser does not support the video tag.
      </video>
     
    </div>
  );
}

export default VideoPlayer;
