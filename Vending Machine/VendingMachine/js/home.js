$(document).ready(function(){
loadVending();
vendingMachine();
})

function loadVending() {
  //clearContactTable()
  var contentRows1 = $('#contentRows1');
    var contentRows2 = $('#contentRows2');
      var contentRows3 = $('#contentRows3');
  var i = 1;
  $.ajax({
    type: 'GET',
    url: 'http://localhost:8080/items',
    success: function(itemArray) {
        $.each(itemArray, function(index, item) {
          var name = item.name;
          var price = item.price;
          var quantity = item.quantity;
          var itemId = item.id;
          var num = price;
          var n=num.toFixed(2);

              if(i>0 && i<4)
              {
              var row = '<div class="col-md-3"id="rowOne">';
              row +=  itemId;
              row +=  '<div id="name">' + name + '</div><br>';
              row += '<div id="price">$' + n + '</div><br><br>';
              row += '<div id="quantity">Quantity Left: ' + quantity + '</div>';
              row += '</div>'
       
              contentRows1.append(row);
                   i++;
              }
             
              else if(i>3 && i<7)
              {
              row = '<div class="col-md-3"id="rowOne">';
              row +=  itemId;
              row +=  '<div id="name">' + name + '</div><br>';
              row += '<div id="price">$' + n + '</div><br><br>';
              row += '<div id="quantity">Quantity Left: ' + quantity + '</div>';
              row += '</div>'
              contentRows2.append(row);
              i++;
              }
              else 
               {
              row = '<div class="col-md-3"id="rowOne">';
              row +=  itemId;
              row +=  '<div id="name">' + name + '</div><br>';
              row += '<div id="price">$' + n + '</div><br><br>';
              row += '<div id="quantity">Quantity Left: ' + quantity + '</div>';
              row += '</div>'
              contentRows3.append(row);
              i++;
               }
            
                
            
           
       

       
        });
    },
    error: function(){
        $('#errorMessages')
           .append($('<li>')
           .attr({class: 'list-group-item list-group-item-danger'})
           .text('Error calling web service. Please try again later.'));
    }
  });
}

function vendingMachine(id){
  var total = 0;

$('#add-dollar-button').click(function(event){
total += 1.00;
$('#totalIn').val('$'+total.toFixed(2));
})

$('#add-quarter-button').click(function(event){
  total += .25;
  $('#totalIn').val('$'+total.toFixed(2));
})

$('#add-dime-button').click(function(event){
  total+= .10;
  $('#totalIn').val('$'+total.toFixed(2));
})
$('#add-nickel-button').click(function(event){
  total+= .05;
  $('#totalIn').val('$'+total.toFixed(2));
})
$('#make-purchase-button').click(function(event){
  id = $('#itemId').val();
    $.ajax({
    type: 'GET',
    url: 'http://localhost:8080/money/' + total+ '/item/' + id,
    success: function(data) {
       $('#messages').val('Thank you!');
   
         $('#change').val(data.quarters + ' Quarter '+ data.dimes+' Dimes ' + 
          + data.nickels + ' Nickels ' + data.pennies + ' Pennies ' );
       
       $('#change-return-button').click(function(event){
         location.reload();
       })
     
    },
    error : function(data,xhr){
     
  $('#messages').val(JSON.parse(data.responseText).message);
    
    }
  })
})
}
