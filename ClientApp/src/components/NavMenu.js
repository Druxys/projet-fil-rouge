import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);
    }

 

    render() {
        return (
            <div className="d-flex flex-column flex-shrink-0 p-3 text-white bg-dark test" >
                <ul className="nav nav-pills flex-column mb-auto">
                    <li>
                        <NavLink tag={Link} className="text-white" to="/">Recette</NavLink>
                    </li>
                    {/*<li>*/}
                    {/*    <NavLink tag={Link} className="text-white" to="/counter"></NavLink>*/}
                    {/*</li>*/}
                    <li>
                        <NavLink tag={Link} className="text-white" to="/fetch-data">Fetch data</NavLink>
                    </li>
                    <li>
                        <NavLink tag={Link} className="text-white" to="/articles">Articles</NavLink>
                    </li>
                </ul>
            </div>
        )
    }
}
