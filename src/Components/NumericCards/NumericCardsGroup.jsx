import React from 'react'
import SingleCard from './SingleCard'
import './numeric-cards.css'

export default function NumericCardsGroup() {
  return (
    <div className='numeric-cards' style={{display: 'flex'}}>
        <SingleCard title="test" data="1234"/>
        <SingleCard title="test" data="1234"/>
        <SingleCard title="test" data="1234"/>
        <SingleCard title="test" data="1234"/>
    </div>
  )
}
