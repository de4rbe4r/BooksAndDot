import React, { Component } from 'react'

export class Categories extends Component {
    constructor(props) {
        super(props)
        this.state = {
            Categories: [
                {
                    key: 'all',
                    name: 'Всё'
                }
                {
                    key: 'Authors',
                    name: 'Авторы'
                }
                 {
                    key: 'Books',
                    name: 'Книги'
                }
                
            ]
        }
    }
    render() {
        return (
            <div className='categories'>
                {this.state.Categories.map(el =>(
                    <div> key={el.key}>{el.name}</div>
                ))}
            </div>
        )
    }
}

export default Categories 

