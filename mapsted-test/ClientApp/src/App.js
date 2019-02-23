import React, { Component } from "react";
import { Container, Header } from "semantic-ui-react";
import Input from './components/Input'
import { SortUI } from './components/SortUI'
import { ProgressBar } from 'react-bootstrap'

class App extends Component {

    constructor(props) {
        super(props)
        this.state = {
            status: 0
        }
        this.child = React.createRef();
        this.showSortUI.bind(this);
        this.updateStatusBar.bind(this)
    }

    showSortUI = (sortSnapShots) => {
        this.child.current.renderSorting(sortSnapShots); 
    }

    updateStatusBar = (status) => {
        this.setState({ status: status});
    }

    render() {
        return (
            <Container style={{ margin: 20 }}>
                <Header as="h3">Sort Demo!</Header>
                <Input ShowSortUI={this.showSortUI} />
                <SortUI UpdateStatus={this.updateStatusBar} ref={this.child} />
                <ProgressBar now={this.state.status} animated={"true"} style={{ marginTop: 25 }} />
            </Container>)
    }
}

export default App;


