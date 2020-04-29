$(document).ready(function () {
    var heroSlider = $('.home-slider .owl-carousel');
    heroSlider.owlCarousel({
        items: 1,
        animateOut: 'fadeOut',
        mouseDrag: true,
        touchDrag: true,
        loop: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: false,
        nav: true
    });

})