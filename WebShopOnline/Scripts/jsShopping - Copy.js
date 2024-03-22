$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function () {
        //event.preventDefault();
        var id = $(this).data('id');
        var quantity = 1;
        var tQuantity = $('#quantity_value').text();
        if (tQuantity != '') {
            quantity = parseInt(tQuantity);
        }
        //alert(id + "  " + quantity);
        $.ajax({
            url: '/shoppingcart/addtocart',
            type: 'POST',
            data: { id: id, quantity: quantity },
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.Count);
                    alert(rs.msg);
                }
            }
        });
    });

    $('body').on('click', '.btnDelete', function (event) {
        event.preventDefault();
        var id = $(this).data('id');
        var conf = confirm('Bạn có chắc chắn muốn xóa sản phẩm này khỏi giỏ hàng?');
        if (conf == true) {
            $.ajax({
                url: '/shoppingcart/Delete',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.Success) {
                        $('#checkout_items').html(rs.Count);
                        $('#trow_' + id).remove();
                        LoadCart();
                    }
                }
            });
        }
    });

    $('body').on('click', '.btnDeleteAll', function (event) {
        event.preventDefault();
        var conf = confirm('Bạn có chắc chắn muốn xóa hết sản phẩm khỏi giỏ hàng?');
        if (conf == true) {
            DeleteAll();
        }
    });

    $('body').on('click', '.btnUpdate', function (event) {
        event.preventDefault();
        var id = $(this).data('id');
        var quantity = $('#Quantity_' + id).val();
        Update(id, quantity);
    });
});

function ShowCount() {
    $.ajax({
        url: '/shoppingcart/ShowCount',
        type: 'GET',
        success: function (rs) {
            $('#checkout_items').html(rs.Count);
        }
    });
}

function DeleteAll() {
    $.ajax({
        url: '/shoppingcart/DeleteAll',
        type: 'POST',
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
                $('#checkout_items').html(0);
            }
        }
    });
}
function Update(id, quantity) {
    $.ajax({
        url: '/shoppingcart/Update',
        type: 'POST',
        data: { id: id, quantity: quantity },
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}
function LoadCart() {
    $.ajax({
        url: '/shoppingcart/Partial_Item_Cart',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}

