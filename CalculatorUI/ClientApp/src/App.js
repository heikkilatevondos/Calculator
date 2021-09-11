import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { SumValues} from './components/SumValues';
import { PrimeCheck } from './components/PrimeCheck';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
            <Route path='/sumvalues' component={SumValues} />
        <Route path='/primecheck' component={PrimeCheck} />
            <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
}
