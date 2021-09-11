import React, { Component } from 'react';

export class PrimeCheck extends Component {
    static displayName = PrimeCheck.name;

    constructor(props) {
        super(props);
        this.state = { isPrime: false, valueFetched: false, inputValue: '' };

        this.handleCheckPrimeClick = this.handleCheckPrimeClick.bind(this);
        this.updateInputValue = this.updateInputValue.bind(this);
    }

    static renderResult(isPrime) {
        return (
            <div>
                <p> IsPrime = {isPrime ? 'True' : 'False'}</p>
            </div>
        );
    }

    handleCheckPrimeClick() {

        if (this.state.inputValue != "") {

            this.getResult();
        }

    }

    updateInputValue(evt) {
        this.setState({
            inputValue: evt.target.value,
            valueFetched: false
        });
    }

    render() {
        var contents = "";
        if (this.state.inputValue == "") {
            contents = "Insert input value";
        }
        else if (this.state.valueFetched) {
            contents = PrimeCheck.renderResult(this.state.isPrime)
        }
        else {
            contents = "";
        }

        return (
            <div>
                <h1 id="tabelLabel">Check prime</h1>
                <p>
                    <label>Input value</label>
                </p>
                <p>
                    <input value={this.state.inputValue} onChange={evt => this.updateInputValue(evt)} />
                </p>
                <p>
                    <button onClick={this.handleCheckPrimeClick}>Check Prime</button>
                </p>
                {contents}
            </div>
        );
    }

    async getResult() {

        var url = "https://localhost:44305/CalculatorAPI/checkprime?number=" + this.state.inputValue;
        fetch(url)
            .then(response => response.json())
            .then(data => this.setState(
                { isPrime: data, valueFetched: true }
            ));
    }
}
