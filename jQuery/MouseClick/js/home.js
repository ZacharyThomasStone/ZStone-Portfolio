$(document).ready(function(){
    $('#toggleNumbers').on('click', function(){
        $('h2').toggle('fast');
    });
    $('#centerUp').on('click', function(){
      $('h1').addClass('text-center');
      $('h2').addClass('text-center');
      $('#buttonDiv').addClass('text-center');
    });
    $('#headingsBlue').on('click',function () {
      $('h1').css('color','blue');
    });
    $('div').hover(
      //in function
      function(){
        $(this).css('background-color', 'CornflowerBlue');
      },
      //out function
      function(){
        $(this).css('background-color', '');
      }
    );
    $('h2').hover(
      //in function
      function(){
        $(this).css('color', 'DarkOrange');
      },
      //out function
      function() {
        $(this).css('color','');
      }
    );
    $('#mainHeading').hover(
      //in function
      function(){
        $(this).css('color','red');
      },
      function(){
        $(this).css('color','pink');
      }
    );
});
