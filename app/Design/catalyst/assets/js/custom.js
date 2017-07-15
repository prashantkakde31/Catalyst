$(document).ready(function () {
    
    //Page specific code
    //@page variable defined at head section
    
    
    switch ( page ) {

        case 'home':{
        //home page
        }
        break;


        case 'login-register':{
        //login register
        }
        break;


        case 'mcq-test':{
            
            //MCQ help modal handling
            $('.modal-mcqhelp')
                .on('show.bs.modal', function (e) {
                    var targetHempBlock = $(e.relatedTarget).attr('data-source');                
                    $(this).find('.modal-body').html($(targetHempBlock).html());
                })
                .on('hide.bs.modal', function (e) {
                    $(this).find('.modal-body').html('');
                });
            
            //Test           
            function callback(){console.log('callback')};
            
            MCQ_MODULE.init();
            MCQ_MODULE.startTimer();
            
            events.on('testModInitialized',function(data){
                console.log('testModInitialized');
            });
        }
        break;
    }
});