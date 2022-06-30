import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { ArticleDetails } from './components/ArticleDetails';
import { Articles } from './components/Articles';
import { ArticlesForm } from './components/ArticlesForm';
import { Counter } from './components/Counter';
import { Fettchdata } from './components/fettchdata';
import { Home } from './components/Home';
import { Layout } from './components/Layout';
import './custom.css';


export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Switch>
                <Layout>
                    <Route exact path="/">
                        <Home />
                    </Route>
                    <Route path="/counter">
                        <Counter />
                    </Route>
                    <Route path="/fetch-data">
                        <Fettchdata />
                    </Route>
                    <Route path="/articles">
                        <Articles />
                    </Route>
                    <Route exact path="/article/:id">
                        <ArticleDetails />
                    </Route>
                    <Route path="/new-article">
                        <ArticlesForm />
                    </Route>
                </Layout>
            </Switch>
        );
    }
}
