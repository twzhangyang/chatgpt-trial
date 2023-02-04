import React from 'react';
import { render, screen } from '@testing-library/react';
import HomePage from './HomePage';

describe('HomePage', () => {
  it('should render a container', () => {
    render(<HomePage />);
    const container = screen.getByRole('container');
    expect(container).toBeInTheDocument();
  });

  it('should render a card', () => {
    render(<HomePage />);
    const card = screen.getByRole('card');
    expect(card).toBeInTheDocument();
  });

  it('should render a header in the card', () => {
    render(<HomePage />);
    const header = screen.getByRole('heading', { name: /Welcome to the Home Page/ });
    expect(header).toBeInTheDocument();
  });

  it('should render a button', () => {
    render(<HomePage />);
    const button = screen.getByRole('button', { name: /Learn More/ });
    expect(button).toBeInTheDocument();
  });
});
