import React, { Component } from 'react';

export class SumValues extends Component {
    static displayName = SumValues.name;

    constructor(props) {
        super(props);
        this.state = { sum: 0, isPrime: false, valuesFetched: false, inputValues: '' };

        this.handleCalculateClick = this.handleCalculateClick.bind(this);
        this.updateInputValues = this.updateInputValues.bind(this);
    }

    static renderResult(sum, isPrime) {
        return (
            <div>
                <p> Sum = {sum}</p>
                <p> IsPrime = {isPrime ? 'True' : 'False'}</p>
            </div>
        );
    }

    handleCalculateClick() {

        if (this.state.inputValues != "") {

            this.getResult();
        }

    }

    updateInputValues(evt) {
        this.setState({
            inputValues: evt.target.value,
            valuesFetched: false
        });
    }

    render() {
        var contents = "";
        if (this.state.inputValues == "") {
            contents = "Insert input values";
        }
        else if (this.state.valuesFetched) {
            contents = SumValues.renderResult(this.state.sum, this.state.isPrime)
        }
        else {
            contents = "";
        }

        return (
            <div>
                <h1 id="tabelLabel">Sum values</h1>
                <p>
                    <label>Input values</label>
                </p>
                <p>
                    <input value={this.state.inputValue} onChange={evt => this.updateInputValues(evt)} />
                </p>
                <p>
                    <button onClick={this.handleCalculateClick}>Calculate</button>
                </p>
                {contents}
            </div>
        );
    }

    async getResult() {

        var url = "https://localhost:44305/CalculatorAPI/sum?numbers=" + this.state.inputValues;
        fetch(url)
            .then(response => response.json())
            .then(data => this.setState(
                { sum: data.sum, isPrime: data.isPrime, valuesFetched: true }
            ));
    }
}

