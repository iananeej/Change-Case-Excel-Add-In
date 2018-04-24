// preloader
$(window).load(function () {
    testConnection();
    $('.preloader').fadeOut(1000); // set duration in brackets     
});

$('#blog').onclick = function () {
    location.href = "https://www.aneejian.com";
};

$(function () {
    new WOW().init();
    $('.templatemo-nav').singlePageNav({
        offset: 70
    });

    /* Hide mobile menu after clicking on a link
    -----------------------------------------------*/
    $('.navbar-collapse a').click(function () {
        $(".navbar-collapse").collapse('hide');
    });
});

function changePage(event) {
    if ($(event.target).hasClass('external')) {
        window.location.href = $(event.target).attr('href');
        return;
    }
    //...
}
$(function () {
    $('.nav li').click(changePage);
});

function testConnection() {
    var playerFrame = document.getElementById('ytplayer');
    var youTube = 'https://www.youtube.com/embed/KmaOW4PhuII?rel=0';
    var youTubeNoCookie = 'https://www.youtube-nocookie.com/embed/KmaOW4PhuII?rel=0';
    var vimeo = 'https://player.vimeo.com/video/265899201';
    try {
        var image = new Image();
        image.onload = function () {
            playerFrame.setAttribute('src', youTube);
        };
        image.onerror = function () {
            var image2 = new Image();
            image2.onload = function () {
                playerFrame.setAttribute('src', youTubeNoCookie);
            };
            image2.onerror = function () {
                playerFrame.setAttribute('src', vimeo);
            };
            image2.src = "https://www.youtube-nocookie.com/favicon.ico";
        };
        image.src = "https://youtube.com/favicon.ico";
    } catch (error) {
        playerFrame.setAttribute('src', youTube);
    }
}