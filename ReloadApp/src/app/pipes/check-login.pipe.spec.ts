import { CheckLoginPipe } from './check-login.pipe';

describe('CheckLoginPipe', () => {
  it('create an instance', () => {
    const pipe = new CheckLoginPipe();
    expect(pipe).toBeTruthy();
  });
});
