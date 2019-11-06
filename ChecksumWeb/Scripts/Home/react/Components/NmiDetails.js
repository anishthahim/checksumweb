import React, { Component } from "react";

class NmiDetails extends Component {
  state = {};
  render() {
    const { nmiValue, checksum, isNmiValid, isChecksumCalc, message } = {
      ...this.props
    };
    return (
      <React.Fragment>
        <div
          className={this.getResultBoxStyle()}
          style={{ maxWidth: 100 + "rem" }}
        >
          <div className="card-header">NMI Checksum - Result Box</div>
          <div className="card-body">
            <p className="card-text">NMI : {nmiValue}</p>
            <p className="card-text">Checksum : {checksum}</p>
            <p className="card-text">Message : {message}</p>
          </div>
        </div>
      </React.Fragment>
    );
  }

  getResultBoxStyle = () => {
    return this.props.isNmiValid == false
      ? "card text-white bg-danger mb-3"
      : this.props.isChecksumCalc == true
      ? "card text-white bg-success mb-3"
      : "card text-white bg-secondary mb-3";
  };
}

export default NmiDetails;
