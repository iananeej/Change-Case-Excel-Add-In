setInterval(removePreloader, 10000);
function removePreloader(params) {
    $('.preloader').fadeOut(1000);
}

$(window).ready(function () {    
    if ($('#ytplayer').length) {
        testYouTubeConnection();
    }
});

// preloader
// $('#github').load(function () {
//     console.log('github loaded');
//     $('.preloader').fadeOut(1000);
// });

// preloader
$(window).on('load', function () {
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

    $('.head-nav').singlePageNav({
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
}

$(function () {
    $('.nav li').click(changePage);
});

$(function () {
    $('.nav-link').click(changePage);
    $('.navbar-brand').click(changePage);
});


function testYouTubeConnection() {
    var playerFrame = $('#ytplayer');
    var youTube = 'https://www.youtube.com/embed/KmaOW4PhuII?rel=0';
    var youTubeNoCookie = 'https://www.youtube-nocookie.com/embed/KmaOW4PhuII?rel=0';
    var vimeo = 'https://player.vimeo.com/video/265899201';
    playerFrame.attr('src', vimeo);
    try {
        var image = new Image();
        image.onload = function () {
            playerFrame.attr('src', youTube);
        };
        image.onerror = function () {
            var image2 = new Image();
            image2.onload = function () {
                playerFrame.attr('src', youTubeNoCookie);
            };
            image2.onerror = function () {
                playerFrame.attr('src', vimeo);
            };
            image2.src = "https://www.youtube-nocookie.com/favicon.ico";
        };
        image.src = "https://youtube.com/favicon.ico";
    } catch (error) {
        playerFrame.attr('src', vimeo);
    }
}