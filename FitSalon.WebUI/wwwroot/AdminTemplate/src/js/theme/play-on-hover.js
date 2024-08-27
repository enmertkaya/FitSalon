const playOnHoverInit = () => {
  const videos = document.querySelectorAll('[data-play-on-hover]');
  if (videos) {
    videos.forEach(video => {
      video.addEventListener('mouseover', () => {
        video.play();
      });

      video.addEventListener('mouseout', () => {
        video.pause();
      });

      video.addEventListener('touchstart', () => {
        video.play();
      });

      video.addEventListener('touchend', () => {
        video.pause();
      });
    });
  }
};

export default playOnHoverInit;
