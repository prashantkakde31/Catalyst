/*!
 * jQuery addnew PLugin
 * =====================
 * Add new line of form element
 */

;(function ( $, window, document, undefined ) {    
    

    // Create the defaults once
    var pluginName = 'addNewForm',
        defaults = {
            
        };

    // The actual plugin constructor
    function Plugin( element, options ) {
        this.element = element;        
        this.options = $.extend( {}, defaults, options);        
        this._defaults = defaults;
        this._name = pluginName;        
        this.init();
    }

    Plugin.prototype.init = function () {
        var self = this;
        this.addBtnEl = $(this.options.addButton);
        this.addRowEl = $('<div class="addNewrow"></div>');
        //console.log(this.addBtnEl);
        
        //Generate html
        $(this.element).html(this.addRowEl);
        $(this.addRowEl).html(this.options.template);
        $(this.addRowEl).append(this.addBtnEl);

        this.formRowEl = $(this.addRowEl);
        
        //initclick
        this.initAddClick(this.addBtnEl);
       
    };
    
    Plugin.prototype.initAddClick = function(addBtn){
        var self = this;
       
        addBtn.on('click',function(){
           $(this).replaceWith($(self.options.removeButton)).off('click');
           appendNewRow(self);
        });
    };
    
    //Private Funtions
    function appendNewRow(obj){
        
        var $formRow = $('<div class="addNewrow"></div>');
        var $addBtn = $(obj.options.addButton);
        
        $(obj.element).prepend($formRow);//row
        $($formRow).html(obj.options.template);//template
        $($formRow).append($addBtn);//add button
        obj.initAddClick($addBtn);
        
    }

   //Start
    $.fn[pluginName] = function ( options ) {
        return this.each(function () {                
            new Plugin( this, options );            
        });
    }

})( jQuery, window, document );