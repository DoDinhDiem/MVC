// JS slider


// SlineShow
$("#slideshow > div:gt(0)").hide();
var stt = 0;
var endImg = $("img.slide:last").attr("idx");
$(".button").click(function () {
  stt = $(this).attr("idx");

  $("img.slide").hide();
  $("img.slide").eq(stt).show();
  $(".button").removeClass("active");
  $(".button").eq(stt).addClass("active");
});

var interval;
var timer = function () {
  interval = setInterval(function () {
    $("#next").click();
  }, 4000);
};

timer();
$("img.slide").hide();
$("img.slide").eq(stt).show();
$(".button").removeClass("active");
$(".button").eq(stt).addClass("active");
var changeImg = function (stt) {
  $("img.slide").hide();
  $("img.slide").eq(stt).show();
  $(".button").removeClass("active");
  $(".button").eq(stt).addClass("active");

  clearInterval(interval);
  timer();
};

$(".button").click(function () {
  stt = $(this).attr("idx");
  changeImg(stt);
});

$("#next").click(function () {
  if (++stt > endImg) {
    stt = 0;
  }

  changeImg(stt);
});

$("#prev").click(function () {
  if (--stt < 0) {
    stt = endImg;
  }

  changeImg(stt);
});







$(document).ready(function(){
  $('.click_sale-1').click(function(){
    $(this).css('background', '#000')
    $(this).css('color','#fff')
    $('.mobile_sale').css('display','block')
    $('.accessory_sale').css('display', 'none')
    $('.click_sale-2').css('background', '#fff')
    $('.click_sale-2').css('color','#000')
  });

  $(".click_sale-2").click(function(){
    $(this).css('background', '#000')
    $(this).css('color','#fff')
    $(".accessory_sale").css('display','block')
    $(".mobile_sale").css('display', 'none')
    $(".click_sale-1").css('background', '#fff')
    $(".click_sale-1").css('color','#000')
  });
});


// js trang chi tiết
$(document).ready(function(){
  $(".show-more").click(function(){
    $('.show-more-p').slideDown();
      $(this).css("display","none")
      $('.show-more-top').css("display","block")
  });
  $(".show-more-top").click(function(){
      $('.show-more-p').slideUp();
      $(this).css('display','none')
      $('.show-more').css('display',"block")
  });
});



