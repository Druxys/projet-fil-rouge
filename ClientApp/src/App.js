import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Fettchdata } from './components/fettchdata';
import { Counter } from './components/Counter';
import { ArticleDetails } from './components/ArticleDetails';

import './custom.css'
import { Articles } from './components/Articles';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={Fettchdata} />
        <Route path='/articles' component={Articles} />
        <Route path='/article/:id' component={ArticleDetails} />
      </Layout>
    );
  }
}
