import React, { Component } from 'react';
import * as d3 from "d3";


export class SortUI extends Component {

    constructor(props) {
        super(props)
        this.state = {}
        this.updateRenderStatus = this.updateRenderStatus.bind(this);
    }

    updateRenderStatus = (status) => {
        this.props.UpdateStatus(status);
    }

    renderSorting(sortedArr) {
        var data = [];
        if (this.state.renderIntervalId) {
            clearInterval(this.state.renderIntervalId);
        }

        // prepare render data
        if (Array.isArray(sortedArr)) {
            for (let i = 0; i < sortedArr.length; i++) {
                var sortSnapshot = [];
                for (let n = sortedArr[i].length - 1; n >= 0 ; n--) {
                    sortSnapshot.push({ "id": n, "val": sortedArr[i][n] })
                }
                data.push(sortSnapshot);
            }
        }

        // render sort
        let i = 0;
        var pushRender = () => {
            if (i < data.length ) {
                this.renderChart(data[i]);
                this.updateRenderStatus(i / (data.length - 1) * 100);
                i++;
            } else {
                return
            }
        }

        pushRender();
        var renderIntervalId = setInterval(pushRender, 500);
        this.setState({ renderIntervalId: renderIntervalId })
    }

    renderChart(data) {
        if (!Array.isArray(data)) {
            return
        }

        d3.select("svg").remove();
        // set the dimensions and margins of the graph
        var margin = { top: 20, right: 20, bottom: 30, left: 200 },
            width = 960 - margin.left - margin.right,
            height = 300 - margin.top - margin.bottom;

        // set the ranges
        var y = d3.scaleBand()
            .range([height, 0])
            .padding(0.1);

        var x = d3.scaleLinear()
            .range([0, width]);

        // append the svg object to the body of the page
        var svg = d3.select("body").append("svg")
            .attr("width", width + margin.left + margin.right)
            .attr("height", height + margin.top + margin.bottom)
            .append("g")
            .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

        // Scale the range of the data in the domains
        x.domain([0, d3.max(data, function (d) { return d.val; })])
        y.domain(data.map(function (d) { return d.id; }));

        // append the rectangles for the bar chart
        svg.selectAll(".bar")
            .data(data)
            .enter().append("rect")
            .attr("class", "bar")
            .attr("width", function (d) { return x(d.val); })
            .attr("y", function (d) { return y(d.id); })
            .attr("height", y.bandwidth())
            .attr("fill", "blue");

        //add a value label to the right of each bar
        svg.selectAll(".text")
            .data(data)
            .enter()
            .append("text")
            .attr("class", "label")
            .attr("y", function (d) {
                return y(d.id) + y.bandwidth() / 2 + 4;
            })
            .attr("x", function (d) {
                return x(d.val) - d.val.toString().length * 8;
            })
            .attr("fill", "white")
            .text(function (d) {
                return d.val;
            });
    }

    render() {

        return(
            <div>
            </div>      
            )
    }
}


