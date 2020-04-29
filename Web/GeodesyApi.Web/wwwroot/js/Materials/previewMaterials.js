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
}
