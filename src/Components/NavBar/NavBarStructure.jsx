import React from 'react'

export default function NavBarStructure(props) {
  return (
  <div>
    <ul className='nav-bar_ul'>
        {props.items.map((item, index) => {
            return(
            <li key={index}>
                {item.name}
            </li>
            )
        })}
    </ul>
  </div>
  )
}
