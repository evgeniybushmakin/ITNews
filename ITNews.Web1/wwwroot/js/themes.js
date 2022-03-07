$("#theme").on("change", function () {
    var item = $("#theme option:selected").text();
    $.post("/Main/SetTheme",
        {
            data: item
        }).done(function () {
            window.location.reload();
        });

});