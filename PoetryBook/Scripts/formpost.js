$(document).ready(function () {
    $("#btnCompleteInstall").click(function () {

        var data = "{";
        data += '"mail":"' + $("#mail").val() + '",';
        data += '"nick":"' + $("#nick").val() + '",';
        data += '"pass":"' + $("#pass").val() + '",';
        data += '"pass2":"' + $("#pass2").val() + '"';
        data += "}";
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            url: '/Home/InstallAsync',
            data: data,
            success: function (res) {
                if (res.success == true) {
                    window.location = "/";
                }
                else {
                    alert(res.text);
                }
            },
            error: function (msg) {
                alert("hata " + msg.text);
            },
        });

    });
    $("#btnCreateUser").click(function () {

        var data = "{";
        data += '"mail":"' + $("#mail").val() + '",';
       data += '"namesur":"' + $("#namesur").val() + '",';
        data += '"dtS":"' + $("#dt").val() + '",';
        data += '"nick":"' + $("#nick").val() + '",';
        data += '"pass":"' + $("#pass").val() + '",';
        data += '"sec":"' + $("#sec").val() + '",';
        data += '"pass2":"' + $("#pass2").val() + '",';
        data += '"gender":"' + $("#gender").val() + '"';
        data += "}";
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            url: '/Account/CreateAsync',
            data: data,
            success: function (res) {
                if (res.success == true) {
                    window.location = "/";
                }
                else {
                    alert(res.text);
                }
            },
            error: function (msg) {
                alert("hata " + msg.text);
            },
        });

    });
    $("#btnLogin").click(function () {

        var data = "{";
        data += '"mail":"' + $("#maillog").val() + '",';
        data += '"pass":"' + $("#passlog").val() + '",';
        data += '"remember":"'+ $("#remember").val() +'"';
        data += "}";
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            url: '/Account/LoginAsync',
            data: data,
            success: function (res) {
                if (res.success == true) {
                    window.location = "/";
                }
                else {
                    alert(res.text);
                }
            },
            error: function (msg) {
                alert("hata " + msg.text);
            },
        });

    });
    $(".deletepoetryinlist").click(function () {
        if (confirm('Şiiri Silmek İstiyor musunuz?')) {
            var id = $(this).attr("id").split("_");

            $.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                url: '/Admin/Poet/DeletePoetryAsync',
                data: '{"id":' + id[1] + '}',
                success: function (res) {
                    alert("İşlem Başarılı");
                    $("#r_" + id[1]).hide();
                    $("#r_" + id[1]).remove();
                },
                error: function (msg) {
                    alert("hata " + msg.d.text);
                },
            });
        } $(".btn-default").attr("disabled", false);
    });

    $(".deletepoetinlist").click(function () {
        if (confirm('Şairi Silmek İstiyor musunuz?')) {
            var id = $(this).attr("id").split("_");

            $.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                url: '/Admin/Poet/DeletePoetAsync',
                data: '{"id":' + id[1] + '}',
                success: function (res) {
                    alert("İşlem Başarılı");
                    $("#r_" + id[1]).hide();
                    $("#r_" + id[1]).remove();
                },
                error: function (msg) {
                    alert("hata " + msg.d.text);
                },
            });
        } $(".btn-default").attr("disabled", false);
    });
    $(".deletecatinlist").click(function () {
        if (confirm('Kategoriyi Silmek İstiyor musunuz?')) {
            var id = $(this).attr("id").split("_");

            $.ajax({
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                url: '/Admin/Category/DeleteCatAsync',
                data: '{"catid":' + id[1] + '}',
                success: function (res) {
                    alert("İşlem Başarılı");
                    $("#r_" + id[1]).hide();
                    $("#r_" + id[1]).remove();
                },
                error: function (msg) {
                    alert("hata " + msg.d.text);
                },
            });
        } $(".btn-default").attr("disabled", false);
    });

    $("#btnLangTr").click(function () {
       $.cookie("vktuilang", "tr")
        location.reload();
    });
    $("#btnLangEn").click(function () {
        $.cookie("vktuilang", "eng");
        location.reload();
    });

});