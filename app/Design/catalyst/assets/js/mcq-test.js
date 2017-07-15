var MCQ_MODULE = function () {
    
    var activeTestQ = 1,
        totalQ = 0;
    
    function initTest(){
        
        //Controll Click
        $('.test-nav').on('click','.test-nav-control',testControlClick);
        
        //Pager Html
        var pagerHtml = '';
        
        totalQ = 40;
        for(var i = 1; i <= totalQ; i++){
            pagerHtml += '<li>';
                pagerHtml += '<a href="javascript:void(0)" data-control="pager" data-page="'+i+'" class="test-nav-control" >'+i+'</a>';
            pagerHtml += '</li>';
        }
        
        $('.test-nav-pager .pagination').html(pagerHtml);
        //Page 1 Active
        $($('.test-nav-pager .pagination li').get(0)).addClass('active');
        
        events.emit('testModInitialized',{activeTestQ:activeTestQ,totalQ:totalQ});
        
    }
    
    function testControlClick(){
        
        var source = $(this).attr('data-control');
        
        switch(source){
                
            case 'next':{
                $('.test-nav-pager').animate({
                   
                })
            }
            break;
                
            case 'prev':{
                
            }
            break;
                
            case 'pager':{
                $('.test-nav ul.pagination li').removeClass('active');
                $(this).parent().addClass('active');
                pagerClick($(this).attr('data-page'));
            }
            break;
                
        }
    }
    
    
    function pagerClick(page){
        
        var targetPage = $('.test-body .panel').get(page-1);
        if(page <= totalQ && page != activeTestQ){
            activeTestQ = page;
            $('.test-body .panel').not(targetPage).fadeOut(0,function(){$(targetPage).fadeIn(400)});
            events.emit('testModInitialized',{activeTestQ:activeTestQ,totalQ:totalQ});
            
        }
        
    }
    
    
    function startTimer(){
        var today = new Date();
        targetTime = new Date(today.getFullYear(), today.getMonth(), today.getDate(),today.getHours(),today.getMinutes() + 45,today.getSeconds(),today.getMilliseconds());
        console.log(targetTime);
        
        $('#timer').countdown({until: targetTime,format:'HMS'});//.countdown('pause')
        
    }
    
    function stopTimer(){
    
    }
    
    function pauseTimer(){
        
    } 
    
    events.on('testModInitialized',function(data){
        $('.activeQ').html(data.activeTestQ);         
        $('.totalQ').html(data.totalQ);         
    });
    
    
    return {      
        init:initTest,
        startTimer: startTimer,
    };
}();