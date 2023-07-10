CREATE TABLE ombudsman.info_parameters
(
    id integer NOT NULL ,
    code character varying(15) NOT NULL,
    full_name character varying(500) NOT NULL,
    short_name character varying(250) NOT NULL,
    required_field boolean NOT NULL,
    state_id integer NOT NULL,
    multiple_choice_directory boolean,
    directory_id integer,
    initial_value_date date,
    greatest_value_date date,
    unit_of_measure_id integer,
    regular_exp_digit_field character varying(500),
    after_digit smallint,
    number_digit smallint,
    initial_value_digit_field integer,
    mask character varying(15),
    initial_value_tel_num character varying(15),
    tell_num_length smallint,
    regular_exp_digit_tell_num character varying(500),
    CONSTRAINT info_parameters_pkey PRIMARY KEY (id),
    CONSTRAINT fk_directory FOREIGN KEY (directory_id)
        REFERENCES ombudsman.enum_directory (id),
    CONSTRAINT fk_state FOREIGN KEY (state_id)
        REFERENCES ombudsman.enum_state (id),
    CONSTRAINT fk_unit_of_measure FOREIGN KEY (unit_of_measure_id)
        REFERENCES ombudsman.enum_unit_of_measure (id)
)