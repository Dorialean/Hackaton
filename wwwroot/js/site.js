$(function () {

    //смена цвета для иконок в навбаре
    $("#dashboard").hover(() => $("#dashboard > .row > div.col > img").attr("src", "/img/dashboard-orange.png"),
        () => $("#dashboard > .row > div.col > img").attr("src", "/img/dashboard-white.png"));
    console.log("")
    $("#blank-page").hover(() => $("#blank-page > .row > div.col > img").attr("src", "/img/blank-page-orange.png"),
        () => $("#blank-page > .row > div.col > img").attr("src", "/img/blank-page-white.png"));

    $("#speech").hover(() => $("#speech > .row > div.col > img").attr("src", "/img/speech-bubble-orange.png"),
        () => $("#speech > .row > div.col > img").attr("src", "/img/speech-bubble-white.png"));

    $("#calendar").hover(() => $("#calendar > .row > div.col > img").attr("src", "/img/calendar-orange.png"),
        () => $("#calendar > .row > div.col > img").attr("src", "/img/calendar-white.png"));

    $("#user-img").hover(() => $("#user-img > .row > div.col > img").attr("src", "/img/hacker-orange.png"),
        () => $("#user-img > .row > div.col > img").attr("src", "/img/hacker-white.png"));
});


jQuery(function($) {
    $('#register').on('submit', function(event) {
        if ( validateForm() ) { // если есть ошибки возвращает true
            event.preventDefault();
        }
    });

    function validateForm() {
        $(".text-error").remove();
        
        // Проверка e-mail
        var reg     = /^\w+([\.-]?\w+)*@(((([a-z0-9]{2,})|([a-z0-9][-][a-z0-9]+))[\.][a-z0-9])|([a-z0-9]+[-]?))+[a-z0-9]+\.([a-z]{2}|(com|net|org|edu|int|mil|gov|arpa|biz|aero|name|coop|info|pro|museum))$/i;
        var el_e    = $("#email");
        var v_email = !el_e.val();

        if ( v_email ) {
            alert("Поле e-mail обязательно к заполнению")
        } else if ( !reg.test( el_e.val() ) ) {
            v_email = true;
            alert("Вы указали недопустимый e-mail")
        }
        $("#email").toggleClass('error', v_email );

        // Проверка паролей
        var el_p1    = $("#pass");
        var v_pass = !el_p1.val();
        

        if ( el_p1.val().length < 6 ) {
            alert("Пароль должен быть не менее 6 символов")
        }

        $("#pass1").toggleClass('error', v_pass );

        return (v_email || v_pass);
    }
});