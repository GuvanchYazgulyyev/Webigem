(function ($) {
    'use strict';
    jQuery('.mean-menu').meanmenu({ meanScreenWidth: "991" });
    $(window).on('scroll', function () {
        if ($(this).scrollTop() > 150) { $('.navbar-area').addClass("sticky-nav"); } else { $('.navbar-area').removeClass("sticky-nav"); }
    });
    $('.accordion').find('.accordion-title').on('click', function () {
        $(this).toggleClass('active');
        $(this).next().slideToggle('fast');
        $('.accordion-content').not($(this).next()).slideUp('fast');
        $('.accordion-title').not($(this)).removeClass('active');
    });
    $('.brand-slider').owlCarousel({ loop: true, margin: 30, nav: false, dots: false, autoplay: true, autoplayHoverPause: true, responsive: { 0: { items: 2 }, 568: { items: 3 }, 768: { items: 5 }, 1000: { items: 5 } } })
    $('.portfolio-slider').owlCarousel({ loop: true, margin: 30, dots: false, autoplay: true, autoplayHoverPause: true, nav: true, navText: ["<i class='bx bx-left-arrow-alt'></i>", "<i class='bx bx-right-arrow-alt'></i>"], responsive: { 0: { items: 1 }, 768: { items: 2 }, 1000: { items: 3 } } })
    $('.testimonial-item-slider').owlCarousel({ loop: true, items: 1, dots: false, autoplay: true, autoplayHoverPause: true, nav: true, navText: ["<i class='bx bx-left-arrow-alt'></i>", "<i class='bx bx-right-arrow-alt'></i>"], })
    $('.service-slider').owlCarousel({ center: true, loop: true, margin: 30, dots: false, autoplay: true, autoplayHoverPause: true, nav: true, navText: ["<i class='bx bx-left-arrow-alt'></i>", "<i class='bx bx-right-arrow-alt'></i>"], responsive: { 0: { items: 1 }, 768: { items: 2 }, 1000: { items: 3 } } })
    $('#tabs-item li a').on('click', function (e) {
        $('#tabs-item li, #prices-content .active').removeClass('active').removeClass('fadeInUp');
        $(this).parent().addClass('active');
        var activeTab = $(this).attr('href');
        $(activeTab).addClass('active fadeInUp');
        e.preventDefault();
    });
    $('.play-btn').magnificPopup({ disableOn: 700, type: 'iframe', mainClass: 'mfp-fade', removalDelay: 160, preloader: false, fixedContentPos: false });
    $('.client-slider').owlCarousel({ center: true, loop: true, margin: 30, dots: false, autoplay: true, autoplayHoverPause: true, nav: true, navText: ["<i class='bx bx-left-arrow-alt'></i>", "<i class='bx bx-right-arrow-alt'></i>"], responsive: { 0: { items: 1 }, 768: { items: 2 }, 1000: { items: 3 } } })
    $('.close-btn').on('click', function () {
        $('.search-overlay').fadeOut();
        $('.search-btn').show();
        $('.close-btn').removeClass('active');
    });
    $('.search-btn').on('click', function () {
        $(this).hide();
        $('.search-overlay').fadeIn();
        $('.close-btn').addClass('active');
    });
    $(".newsletter-form").validator().on("submit", function (event) {
        if (event.isDefaultPrevented()) {
            formErrorSub();
            submitMSGSub(false, "Please enter your email correctly");
        } else { event.preventDefault(); }
    });

    function callbackFunction(resp) {
        if (resp.result === "success") { formSuccessSub(); } else { formErrorSub(); }
    }

    function formSuccessSub() {
        $(".newsletter-form")[0].reset();
        submitMSGSub(true, "Thank you for subscribing!");
        setTimeout(function () { $("#validator-newsletter").addClass('hide'); }, 4000)
    }

    function formErrorSub() {
        $(".newsletter-form").addClass("animated shake");
        setTimeout(function () { $(".newsletter-form").removeClass("animated shake"); }, 1000)
    }

    function submitMSGSub(valid, msg) {
        if (valid) { var msgClasses = "validation-success"; } else { var msgClasses = "validation-danger"; }
        $("#validator-newsletter").removeClass().addClass(msgClasses).text(msg);
    }
    $(".newsletter-form").ajaxChimp({ url: "https://envyTheme.us20.list-manage.com/subscribe/post?u=60e1ffe2e8a68ce1204cd39a5&amp;id=42d6d188d9", callback: callbackFunction });
    $('body').append('<div id="toTop" class="top-btn"><i class="bx bx-chevrons-up"></i></div>');
    $(window).on('scroll', function () { if ($(this).scrollTop() != 0) { $('#toTop').fadeIn(); } else { $('#toTop').fadeOut(); } });
    $('#toTop').on('click', function () { $("html, body").animate({ scrollTop: 0 }, 600); return false; });
    new WOW().init();
    jQuery(window).on('load', function () { jQuery(".preloader").fadeOut(500); });
})(jQuery);