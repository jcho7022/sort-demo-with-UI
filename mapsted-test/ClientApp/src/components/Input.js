import React, { Component } from 'react'
import { Form } from 'semantic-ui-react'
import axios from 'axios'

const optionsSortType = [{ key: 'quick', value: 0, text: 'Quick' }, { key: 'bubble', value: 1, text: 'Bubble' }, { key: 'bucket', value: 2, text: 'Bucket' }]
const optionsValueType = [{ key: 'int', value: 0, text: 'int' }, { key: 'double', value: 1, text: 'double' }]

class Input extends Component {

    constructor(props) {
        super(props)

        this.state = {
            input: '',
            sortType: 0,
            valueType: 0
        }
        this.handleOnSortClick = this.handleOnSortClick.bind(this);
    }

    handleSortTypeChange = (e, { value }) => {
        this.setState({ sortType: value })
    }

    handleValueTypeChange = (e, { value })=> {
        this.setState({ valueType: value})
    }

    updateInputValue = (e) => {
        this.setState({ input: e.target.value })
    }

    handleOnSortClick() {
        let str = this.state.input.replace(/ /g, '');
        let inputs = str.split(',');
        let currRef = this;

        axios.post('api/Sort/' + optionsValueType[this.state.valueType].key, {
            SortType: this.state.sortType,
            Input: inputs
        })
            .then(function (response) {
                currRef.props.ShowSortUI(response.data);
            })
            .catch(function (error) {
                alert("Invlid input");
            });
    }

    render() {
        return (
            <Form>
                <Form.Group widths='equal'>
                    <Form.Input fluid label='Input' placeholder='Input' value={this.state.input} onChange={this.updateInputValue} />
                </Form.Group>
                <Form.Group>
                    <Form.Select fluid label='Sort Type' width={3} options={optionsSortType} placeholder='Sort Type' onChange={this.handleSortTypeChange} defaultValue={optionsSortType[0].value} />
                    <Form.Select fluid label='Value Type' width={3} options={optionsValueType} placeholder='Value Type' onChange={this.handleValueTypeChange} defaultValue={optionsSortType[0].value} />
                </Form.Group>
                <Form.Button onClick={this.handleOnSortClick}>Sort</Form.Button>
            </Form>
        )
    }
}

export default Input
