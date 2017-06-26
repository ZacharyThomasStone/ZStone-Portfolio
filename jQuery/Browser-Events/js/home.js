$(document).ready(function () {
$('#akronInfoDiv').hide();
$('#minneapolisInfoDiv').hide();
$('#louisvilleInfoDiv').hide();
$('h1').css('color','#CCCCCC');
$('#pageContent').css('background-color', '#FFCC00');
$('body').css('background-color', '#003366');
$('tr').not(':first-child').hover(
  //in function
  function(){
    $(this).css('background-color', 'WhiteSmoke');
  },
  //out function
  function(){
    $(this).css('background-color', '');
  }
);
$('#mainButton').on('click',function(){
  $('#akronInfoDiv').hide();
  $('#minneapolisInfoDiv').hide();
  $('#louisvilleInfoDiv').hide();
  $('#mainInfoDiv').show();
  $('#akronWeather').hide();
});

$('#akronButton').on('click',function(){
  $('#akronInfoDiv').show();
  $('#minneapolisInfoDiv').hide();
  $('#louisvilleInfoDiv').hide();
  $('#mainInfoDiv').hide();
  $('#akronWeather').hide();
  $('#akronWeatherButton').on('click', function(){
    $('#akronWeather').toggle('fast');
  });
});
$('#minneapolisButton').on('click',function(){
  $('#akronInfoDiv').hide();
  $('#minneapolisInfoDiv').show();
  $('#louisvilleInfoDiv').hide();
  $('#mainInfoDiv').hide();
  $('#minneapolisWeather').hide();
  $('#minneapolisWeatherButton').on('click', function(){
    $('#minneapolisWeather').toggle('fast');
  });
});
$('#louisvilleButton').on('click',function(){
  $('#akronInfoDiv').hide();
  $('#minneapolisInfoDiv').hide();
  $('#louisvilleInfoDiv').show();
  $('#mainInfoDiv').hide();
  $('#louisvilleWeather').hide();
  $('#louisvilleWeatherButton').on('click', function(){
    $('#louisvilleWeather').toggle('fast');
  });
});
});
