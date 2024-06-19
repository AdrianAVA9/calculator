var Calculator = function () {
    let _calculator;

    let makeOperation = function () {
        let data = JSON.stringify({
            firstNumber: _calculator.find('.js-first-number').val(),
            secondNumber: _calculator.find('.js-second-number').val(),
            operation: _calculator.find('.js-operation').val()
        });

        //Reset error messages
        $('.error-message').html('');

        $.post({
            url: '/api/calculators/make-operation',
            headers: {
                'content-type': 'application/json'
            },
            data

        }).then((response) => {
            console.log(response);
            const result = response.result;
            _calculator.find('.js-result').html(`The result is: ${result}`);

            if (!response.ok)
                alert(response.message)

        }).fail(error => {
            let errors = error.responseJSON?.errors ? error.responseJSON.errors : {};

            if (error.responseJSON.status === 400) {
                $('.error-message').each((index, element) => {
                    let name = $(element).attr('name');
                    $(element).html('');

                    if (errors[name]) {
                        $(element).html(errors[name].join(' | '));
                    }
                });
            }
        });
    };

    let init = function (calculatorContainer) {
        _calculator = $(calculatorContainer);
        _calculator.on('click', '.js-make-operation', makeOperation);
    };

    return {
        init
    }
}();

Calculator.init('.calculator');