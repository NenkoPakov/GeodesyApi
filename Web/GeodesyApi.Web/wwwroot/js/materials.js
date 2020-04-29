

    ($(document).ready(function () {


        /* the Responsive menu script */
        $('body').addClass('js');
    var $menu = $('#menu'),
        $menulink = $('.menu-link'),
        $menuTrigger = $('.has-subnav > a');

        $menulink.click(function (e) {
        e.preventDefault();
    $menulink.toggleClass('active');
    $menu.toggleClass('active');
});

        var add_toggle_links = function () {
            if ($('.menu-link').is(":visible")) {
                if ($(".toggle-link").length > 0) {
    }
    else {
        $('.has-subnav > a').before('<span class="toggle-link"> Open submenu </span>');
                    $('.toggle-link').click(function (e) {
                        var $this = $(this);
    $this.toggleClass('active').siblings('ul').toggleClass('active');
});
}
}
            else {
        $('.toggle-link').empty();
}
}
add_toggle_links();
$(window).bind("resize", add_toggle_links);

}));

(
        $(document).ready(function () {
        var pageWidth = $(window).width();

        $("#hide").click(function () {
            $("#pushleft").removeClass('newClass');
    });
        $("#show").click(function () {
            $("#pushleft").addClass('newClass');
    });
        })
);


        var materialUrls;
        var all;
        var current = -1;
        var materialId;
    
    function myFunction(urls, id) {
            all = urls.length;
        materialId = id;
        materialUrls = urls;
        current = -1;

        viewNextFile()
    }

    function viewNextFile() {
            current = current + 1;

        if (all == 1) {

            document.getElementById("pdf-previewer-download").setAttribute('download', "download");
        document.getElementById("pdf-previewer-download").setAttribute("href", materialUrls[current].replace("http://", "https://").replace("res.cloudinary.com/dv3tfjvk0/image/upload/", "res.cloudinary.com/dv3tfjvk0/image/upload/fl_attachment/"));
        document.getElementById("pdf-previewer").setAttribute("src", materialUrls[current].replace("http://", "https://"));
    }
        else {
            document.getElementById("pdf-previewer-download").setAttribute('download', "download");
        document.getElementById("pdf-previewer-download").setAttribute("href", materialUrls[current].replace("http://", "https://").replace("res.cloudinary.com/dv3tfjvk0/image/upload/", "res.cloudinary.com/dv3tfjvk0/image/upload/fl_attachment/"));
        document.getElementById("pdf-previewer-download").removeAttribute("disabled");
        document.getElementById("pdf-previewer").setAttribute("src", materialUrls[current].replace("http://", "https://"));
        document.getElementById("pdf-previewer-next").removeAttribute("disabled");

            if ((all - 1) == current) {
            document.getElementById("pdf-previewer-next").setAttribute("disabled", "disabled");
    }
            if (current > 0) {
            document.getElementById("pdf-previewer-previous").removeAttribute("disabled");
    }
}

}

    function viewPreviousFile() {
            current = current - 1;

        if (0 == current) {
            document.getElementById("pdf-previewer-previous").setAttribute("disabled", "disabled");
    }
    document.getElementById("pdf-previewer-download").setAttribute("href", materialUrls[current].replace("http://", "https://").replace("res.cloudinary.com/dv3tfjvk0/image/upload/", "res.cloudinary.com/dv3tfjvk0/image/upload/fl_attachment/"));
    document.getElementById("pdf-previewer").setAttribute("src", materialUrls[current].replace("http://", "https://"));
    document.getElementById("pdf-previewer-next").removeAttribute("disabled");
};

    (
        function ConirmDelete() {
            confirm("Сигурни ли сте, че искате да го изтриете!");
    })