$(document).ready(function () {
  $('H1').addClass('text-center');
  $('H2').addClass('text-center');
  $("#myBanner").attr('myBannerHeading', 'page-header');
  $('#yellowHeading').each(function(){
    var text = $(this).html();
  $(this).html(text.replace('The Squad', 'Yellow Team'));
  });
  $('#orangeTeamList').css('color', 'orange');
  $('#blueTeamList').css('color','blue');
  $('#redTeamList').css('color','red');
  $('#yellowTeamList').css('color','yellow');
  $('#yellowTeamList').append($('<li>').text('Joseph Banks'));
  $('#yellowTeamList').append($('<li>').text('Simon Jones'));
  $('#oops').hide();
  $('#footer').append($('<p>').text('Zachary Stone'));
  $('#footer').append($('<p>').text('Zacharythomasstone89@gmail.com'));
  $('#footer').css('font-family', 'Courier');
  $('#footer').css('font-size', '24px');

});
