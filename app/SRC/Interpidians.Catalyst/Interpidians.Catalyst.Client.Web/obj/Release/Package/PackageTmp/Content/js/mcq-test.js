var MCQ_MODULE = function () {

    var activeTestQ = 1,
        totalQ = 0;

    var submitAnswerUrl = '../../Exam/SubmitAnswer';
    var submitExamUrl = '../../Exam/Result';
    var skipAnswerUrl = '../../Exam/SkipAnswer';
    var pauseTimerUrl = '../../Exam/PauseExamTimer';
    var resumeTimerUrl = '../../Exam/ResumeExamTimer';
    var navigateToQuestionUrl = '../../Exam/NavigateToQuestion';

    function initTest() {

        //Controll Click
        $('.test-nav').on('click', '.test-nav-control', testControlClick);

        //Pager Html
        var pagerHtml = '';

        //totalQ = 40;
        totalQ = $('.totalQ').html();
        activeTestQ = $('.activeQ').html();

        /* Pager formation code commented here

        //for(var i = 1; i <= totalQ; i++){
        //    pagerHtml += '<li>';
        //        pagerHtml += '<a href="javascript:void(0)" data-control="pager" data-page="'+i+'" class="test-nav-control" >'+i+'</a>';
        //    pagerHtml += '</li>';
        }
        
        //$('.test-nav-pager .pagination').html(pagerHtml);

        */

        //Page 1 Active
        $($('.test-nav-pager .pagination li').get(activeTestQ - 1)).addClass('active');

        events.emit('testModInitialized', { activeTestQ: activeTestQ, totalQ: totalQ });

        $(document).ajaxStart(function () {

            ajaxindicatorstart('Please wait..');

        }).ajaxStop(function () {

            ajaxindicatorstop();

        });

        //Navigate by pager
        $('a.test-nav-control').on('click', function () {
            debugger;
            var totalQue = $(".totalQ").html();
            var SrNo = $(this).data().page;

            if (Number(SrNo) > Number(totalQue) || Number(SrNo) == 0) {
                return false;
            }
            var examId = $('#QuestionPanel').data().examId;

            var timeLeft = GetTimerCountdown();

            var navigator = new Object();
            navigator.ExamId = examId;
            navigator.TimeLeft = timeLeft;
            navigator.NavigateToSrNo = SrNo;

            CreateAndSubmitForm(navigateToQuestionUrl, "post", "examNavigator", navigator);
        });

        // pause and resume the timer
        $('#btnStopTimer').on('click', function () {
            
            if ($(this).find('.glyphicon-pause').length > 0) {
                $(this).find('.glyphicon-pause').removeClass('glyphicon-pause').addClass('glyphicon-play');
                debugger;
                var examId = $('#QuestionPanel').data().examId;
                var srNo = $('#QuestionPanel').data().questionSrNo;
                var timeLeft = GetTimerCountdown();
                var ans = new Object();
                ans.ExamId = examId;
                ans.SrNo = srNo;
                ans.TimeLeft = timeLeft;
                var ans1 = { examTimer: ans };
                var dataToSend = JSON.stringify(ans1);
                //CreateAndSubmitForm(pauseTimerUrl, "post", "examTimer", ans);
                AjaxCall(pauseTimerUrl, dataToSend, "post", "json", "OnPauseTimerSuccess", "application/json", undefined, undefined);
                //pauseTimer();
            }
            else {
                $(this).find('.glyphicon-play').removeClass('glyphicon-play').addClass('glyphicon-pause');
                debugger;
                var examId = $('#QuestionPanel').data().examId;
                var srNo = $('#QuestionPanel').data().questionSrNo;
                var timeLeft = GetTimerCountdown();
                var ans = new Object();
                ans.ExamId = examId;
                ans.SrNo = srNo;
                ans.TimeLeft = timeLeft;
                var ans1 = { examTimer: ans };
                var dataToSend = JSON.stringify(ans1);
                //CreateAndSubmitForm(resumeTimerUrl, "post", "examTimer", ans);
                AjaxCall(resumeTimerUrl, dataToSend, "post","json", "OnResumeTimerSuccess","application/json", undefined, undefined);
                //resumeTimer();
            }
        });

        //Submit the answer
        $('#btnMarkForReview').on('click', function () {
            debugger;

            var answerId;

            if ($('input[name="currentMcqChoice"]:checked').length > 0) {
                answerId = $('input[name="currentMcqChoice"]:checked').data().answerId;
            }
            else {
                $(this).notify("Please select one option", { position: "top", className: 'error' });
                return false;
            }

            var examId = $('#QuestionPanel').data().examId;
            var mcqId = $('#QuestionPanel').data().questionId;
            var srNo = $('#QuestionPanel').data().questionSrNo;

            var timeLeft = GetTimerCountdown();


            var ans = new Object();
            ans.ExamId = examId;
            ans.McqId = mcqId;
            ans.AnswerId = answerId;
            ans.SrNo = srNo;
            ans.TimeLeft = timeLeft;
            ans.IsMarkForReview = true; //Newly added


            CreateAndSubmitForm(submitAnswerUrl, "post", "answer", ans);

            //AjaxCall(submitAnswerUrl, JSON.stringify({ srNo: srNo, mcqId: mcqId, answerId: answerId, timeLeft: timeLeft }), 'POST', 'json', 'onSuccessSubmitAnswer', 'application/json; charset=utf-8');


        });

        //Submit the answer
        $('#btnSubmitAnswer').on('click', function () {
            debugger;

            var answerId;

            if ($('input[name="currentMcqChoice"]:checked').length > 0) {
                answerId = $('input[name="currentMcqChoice"]:checked').data().answerId;
            }
            else {
                $(this).notify("Please select one option", { position: "top", className: 'error' });
                return false;
            }

            var examId = $('#QuestionPanel').data().examId;
            var mcqId = $('#QuestionPanel').data().questionId;
            var srNo = $('#QuestionPanel').data().questionSrNo;

            var timeLeft = GetTimerCountdown();


            var ans = new Object();
            ans.ExamId = examId;
            ans.McqId = mcqId;
            ans.AnswerId = answerId;
            ans.SrNo = srNo;
            ans.TimeLeft = timeLeft;


            CreateAndSubmitForm(submitAnswerUrl,"post","answer",ans);

            //AjaxCall(submitAnswerUrl, JSON.stringify({ srNo: srNo, mcqId: mcqId, answerId: answerId, timeLeft: timeLeft }), 'POST', 'json', 'onSuccessSubmitAnswer', 'application/json; charset=utf-8');


        });

        //Skip the answer
        $('#btnSkipQuestion').on('click', function () {
            debugger;
            var examId = $('#QuestionPanel').data().examId;
            var mcqId = $('#QuestionPanel').data().questionId;
            var srNo = $('#QuestionPanel').data().questionSrNo;

            var timeLeft = GetTimerCountdown();


            var ans = new Object();
            ans.ExamId = examId;
            ans.McqId = mcqId;
            //ans.AnswerId = answerId;
            ans.SrNo = srNo;
            ans.TimeLeft = timeLeft;


            CreateAndSubmitForm(skipAnswerUrl, "post", "answer", ans);
        });

        //clears the answer selection
        $('#btnClearSelection').on('click', function () {
            $('input[name="currentMcqChoice"]').prop('checked', false);
        });

        //clears the answer selection
        $('#btnSubmitExam').on('click', function () {
            var examId = $('#QuestionPanel').data().examId;
            var timeLeft = GetTimerCountdown();
            var timer = new Object();
            timer.ExamId = examId;
            timer.TimeLeft = timeLeft;

            CreateAndSubmitForm(submitExamUrl, "post", "examTimer", timer);
        });

        
        //disables the ctrl key combinations
        $(document).on('keydown', function (e) {
            disableCtrlKeyCombination(e);
        });

    }

    function testControlClick() {

        var source = $(this).attr('data-control');

        switch (source) {

            case 'next': {
                $('.test-nav-pager').animate({

                })
            }
                break;

            case 'prev': {

            }
                break;

            case 'pager': {
                //$('.test-nav ul.pagination li').removeClass('active');
                //$(this).parent().addClass('active');
                //pagerClick($(this).attr('data-page'));
            }
                break;

        }
    }


    function pagerClick(page) {
        //var targetPage = $('.test-body .panel').get(page - 1);
        //if (page <= totalQ && page != activeTestQ) {
        //    activeTestQ = page;
        //    $('.test-body .panel').not(targetPage).fadeOut(0, function () { $(targetPage).fadeIn(400) });
        //    events.emit('testModInitialized', { activeTestQ: activeTestQ, totalQ: totalQ });

        //}

    }


    function startTimer() {
        var today = new Date();
        var examTime = $('#timer').html().split(":");    //split time left into H M S format
        //targetTime = new Date(today.getFullYear(), today.getMonth(), today.getDate(),today.getHours(),today.getMinutes() + 45,today.getSeconds(),today.getMilliseconds());
        targetTime = new Date(today.getFullYear(), today.getMonth(), today.getDate(), today.getHours() + Number(examTime[0]), today.getMinutes() + Number(examTime[1]), today.getSeconds() + Number(examTime[2]), today.getMilliseconds());
        console.log(targetTime);

        $('#timer').countdown({ until: targetTime, format: 'HMS' });

    }

    function stopTimer() {

    }

    function pauseTimer() {
        $('#timer').countdown('pause');
    }

    function resumeTimer() {
        $('#timer').countdown('resume');
    }

    events.on('testModInitialized', function (data) {
        $('.activeQ').html(data.activeTestQ);
        $('.totalQ').html(data.totalQ);
    });


    //disable keys while exam is going on
    function disableCtrlKeyCombination(e) {

        var forbiddenKeys = new Array('a', 'n', 'x', 'j', 'w', 'c');
        var key;
        var isCtrl;
        if (window.event) {
            key = window.event.keyCode;     //IE
            if (window.event.ctrlKey)
                isCtrl = true;
            else
                isCtrl = false;
        }
        else {
            key = e.which;     //firefox
            if (e.ctrlKey)
                isCtrl = true;
            else
                isCtrl = false;
        }

        //if ctrl is pressed check if other key is in forbidenKeys array
        if (isCtrl) {
            for (i = 0; i < forbiddenKeys.length; i++) {
                //case-insensitive comparation
                if (forbiddenKeys[i] == String.fromCharCode(key).toLowerCase())//.toLowerCase()
                {
                    var key_ctrl_disable = 'Key combination CTRL + ' + String.fromCharCode(key) + ' has been disabled.';
                    e.preventDefault();
                    return false;
                }
            }
        }
        return true;
    }

    //Ajax start/stop function
    function ajaxindicatorstart(text) {

        if (jQuery('body').find('#resultLoading').attr('id') != 'resultLoading') {

            jQuery('body').append('<div id="resultLoading" style="display:none"><div><img src="../../Content/img/ajax-loader.gif"><div>' + text + '</div></div><div class="bg"></div></div>');

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

    function OnPauseTimerSuccess(response)
    {
        pauseTimer();
    }

    function OnResumeTimerSuccess(response) {
        resumeTimer();
    }

    function AjaxCall(url, postData, httpmethod, calldatatype, sucesscallbackfunction, contentType, showLoading, isAsync) {
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
                    //var url = decodeURIComponent(JSON.stringify(window.location.host + data.url)).replace(/\"/g, "");
                    //window.location.href = url;
                    eval(sucesscallbackfunction + '(data)');
                }
            },
            error: function (ee) {
                //alert('Error' + ee);
                ajaxindicatorstop();
            }
        });
    }
    
    function onSuccessSubmitAnswer(response) {
        debugger;
        if (response) {
            $("btnSubmitAnswer").notify("Submitted", { position: "left", className: "success" });
            if (response.result == "Redirect") {
                var url = decodeURIComponent(JSON.stringify(window.location.host + response.url)).replace(/\"/g, "");
                window.location.href = url;
                //return false;
            }
        }
        else {
            $("btnSubmitAnswer").notify("Submission Failed", { position: "left", className: "error" });
        }
    }

    function CreateAndSubmitForm(submitUrl,method,name,value) {

        //delete existing such form
        if ($("#frmDynamicForm").length > 0)
            $("#frmDynamicForm").remove();

        var form = document.createElement("form");
        form.id = "frmDynamicForm";
        form.action = submitUrl; //skipAnswerUrl
        form.method = method;

        var input = document.createElement("input");
        input.setAttribute("type", "hidden");
        input.setAttribute("name", name);   //This must be a parameter name in respective action
        input.setAttribute("value", JSON.stringify(value));

        form.appendChild(input);
        document.body.appendChild(form);
        form.submit();
    }

    function GetTimerCountdown() {
        var timer = $("#timer").countdown('getTimes'); // [0, 0, 0, 0, {H}, {M}, {S}]
        return timer[4] + ":" + timer[5] + ":" + timer[6];
    }

    return {
        init: initTest,
        startTimer: startTimer,
    };
}();