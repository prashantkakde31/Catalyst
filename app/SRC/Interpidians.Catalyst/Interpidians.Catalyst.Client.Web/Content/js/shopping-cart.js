var addItemToCartUrl = '../../../../ShoppingCart/AddItemToCart';
var removeItemFromCartUrl = '../../../../ShoppingCart/RemoveItemFromCart';
var getCartUrl = '../../../../ShoppingCart/GetCart';
var removeAllItemsFromCart = '../../../../ShoppingCart/RemoveAllItemsFromCart';

function InitAjaxCallBack() {
    $(document).ajaxStart(function () {

        ajaxindicatorstart('Please wait..');

    }).ajaxStop(function () {

        ajaxindicatorstop();

    });
}

function AddItemToCart(ctrl) {
    debugger;
    var prodId = $(ctrl).parent()[0].dataset.productId;
    var prodCategory = $(ctrl).parent()[0].dataset.productCategory;
    var prod = { productId: prodId };
    var dataToSend = JSON.stringify(prod);
    AjaxCall(addItemToCartUrl, dataToSend, "post", "json", "OnAddCartItemSuccess", "application/json", undefined, undefined);
    GetCart();
}

function GetCart() {
    debugger;
    AjaxCall(getCartUrl, undefined, "post", "html", "OnGetCartSuccess", "application/json", undefined, undefined);
}

function RemoveItemFromCart(ctrl) {
    debugger;
    var prodId = $(ctrl).parent()[0].dataset.productId;
    var prod = { productId: prodId };
    var dataToSend = JSON.stringify(prod);
    AjaxCall(removeItemFromCartUrl, dataToSend, "post", "json", "OnRemoveCartItemSuccess", "application/json", undefined, undefined);
    GetCart();
}

function EmptyCart() {

}

//Ajax start/stop function
function ajaxindicatorstart(text) {

    if (jQuery('body').find('#resultLoading').attr('id') != 'resultLoading') {

        jQuery('body').append('<div id="resultLoading" style="display:none"><div><img src="../../../../Content/img/ajax-loader.gif"><div>' + text + '</div></div><div class="bg"></div></div>');

    }


    jQuery('#resultLoading .bg').height('100%');

    jQuery('#resultLoading').fadeIn(300);

    jQuery('body').css('cursor', 'wait');

}

function ajaxindicatorstop() {

    jQuery('#resultLoading .bg').height('100%');

    jQuery('#resultLoading').fadeOut(300);

    jQuery('body').css('cursor', 'default');

}

function AjaxCall(url, postData, httpmethod, calldatatype, sucesscallbackfunction, contentType, showLoading, isAsync)
{
    InitAjaxCallBack();

    if (contentType == undefined)
        contentType = "application/x-www-form-urlencoded;charset=UTF-8";

    if (showLoading == undefined)
        showLoading = true;

    if (showLoading == false || showLoading.toString().toLowerCase() == "false")
        showLoading = false;
    else
        showLoading = true;

    if (isAsync == undefined)
        isAsync = true;

    jQuery.ajax({
        type: httpmethod,
        url: url,
        data: postData,
        global: showLoading,
        dataType: calldatatype,
        contentType: contentType,
        async: isAsync,
        success: function (data) {
            debugger;
            if (sucesscallbackfunction != '') {
                eval(sucesscallbackfunction + '(data)');
            }
        },
        error: function (ee) {
            //alert('Error' + ee);
            ajaxindicatorstop();
        }
    });
}

function OnGetCartSuccess(response) {
    console.log("Got Cart");
    $('#UserShoppingCart').html(response);

    //Add scroller again after contents are replaced
    $("#CartItems").mCustomScrollbar({
        theme: 'minimal-dark'
        //scrollButtons: { enable: true },
        //advanced: { autoExpandHorizontalScroll: false, updateOnContentResize: true },
        //axis: "y"
    });
}

function OnAddCartItemSuccess(response) {
    console.log("Item Added");
}

function OnRemoveCartItemSuccess(response) {
    console.log("Item Removed");
}

function OnRemoveAllCartItemSuccess(response) {
    console.log("All Items Added");
}
