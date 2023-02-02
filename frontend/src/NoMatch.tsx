import React from 'react';
import { Link } from 'react-router-dom';

const NoMatch = () => (
  <div>
    <h3>Sorry, the page you are looking for could not be found.</h3>
    <p>
      Please check the URL or go back to the <Link to="/">home page</Link>.
    </p>
  </div>
);

export default NoMatch;
