import React from 'react';

const MySelect = ({children, props, onChange}) => {
    return (
        <select
            {...props}
            className='form-select'
            onChange = {onChange}
        >
            {children}
        </select>
    );
};

export default MySelect;