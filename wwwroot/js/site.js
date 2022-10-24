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

