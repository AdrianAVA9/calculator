var Calculator = function () {
    let _calculator;

    let makeOperation = function () {
        let firstNumber = _calculator.find('.js-first-number').val();
        let secondNumber = _calculator.find('.js-second-number').val();
        let operation = _calculator.find('.js-operation').val();

        $.post('/api/calculator/make-operation', {
            firstNumber, secondNumber, operation
        }).then((response) => {
            console.log(response);

            const result = response.result;
            _calculator.find('.js-result').html(result);
        }).fail(error => {
            console.log(error);
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