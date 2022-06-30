import React, { Component } from 'react';
import { NavMenu } from './NavMenu';
import { Container, Row, Col } from "reactstrap";
export class Layout extends Component {
  static displayName = Layout.name;

  render () {
      return (
         <>
              <Container fluid>
        <Row>
                    <Col xs={2} id="sidebar-wrapper">      
                          <NavMenu />
                    </Col>
                    <Col  xs={10} id="page-content-wrapper">
                         {this.props.children}
                    </Col> 
                </Row>
   
          
      
              </Container>
          </>
    );
  }
}
